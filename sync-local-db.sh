#!/bin/bash

# Environment variables that should be provided by .env file 
# REMOTE_HOST - hostname of the remote database
# REMOTE_PORT - port of the remote database (default: 5432)
# REMOTE_USER - username for the remote database
# REMOTE_DB - database name on the remote server
# REMOTE_PASSWORD - password for the remote database
# PGSSLMODE - set postgres ssl mode
# LOCAL_HOST - hostname of the local database (probably another container)
# LOCAL_PORT - port of the local database (default: 5432)
# LOCAL_USER - username for the local database
# LOCAL_DB - database name on the local server
# LOCAL_PASSWORD - password for the local database

# Load environment files from .env
source .env

TIMESTAMP=$(date +"%Y%m%d_%H%M%S")
DUMP_FILE="/tmp/db_dump_${TIMESTAMP}.sql"

# Use default ports if not specified
REMOTE_PORT=${REMOTE_PORT:-24924}
LOCAL_PORT=${LOCAL_PORT:-5432}

echo "Starting database sync at $(date)"

# Export password variables
export PGPASSWORD=$REMOTE_PASSWORD

# Create a dump of the remote database with SSL required and custom port
echo "Creating dump from ${REMOTE_HOST}:${REMOTE_PORT} with SSL enabled..."
pg_dump -h $REMOTE_HOST -p $REMOTE_PORT -U $REMOTE_USER -d $REMOTE_DB \
        -F custom -f $DUMP_FILE

# Check if dump was successful
if [ $? -ne 0 ]; then
    echo "Error: Database dump failed"
    exit 1
fi

# Switch to local database password
export PGPASSWORD=$LOCAL_PASSWORD

# Restore to local database
echo "Restoring to ${LOCAL_HOST}:${LOCAL_PORT}..."
pg_restore -h $LOCAL_HOST -p $LOCAL_PORT -U $LOCAL_USER -d $LOCAL_DB \
           --clean --if-exists -F custom $DUMP_FILE

# Check if restore was successful
if [ $? -ne 0 ]; then
    echo "Warning: Database restore completed with warnings"
else
    echo "Database restore completed successfully"
fi

# Clean up
rm $DUMP_FILE
echo "Sync completed at $(date)"
