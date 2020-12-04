#!/bin/bash
set -e
echo "file config"

tail -300 /apps/appsettings.json
#if psql -h simpldb --username postgres -lqt | cut -d \| -f 1 | grep -qw simplcommerce; then
#    echo "simplcommerce database existed"
#else
#    echo "create new database simplcommerce"
#	psql -h simpldb --username postgres -c "CREATE DATABASE simplcommerce WITH ENCODING 'UTF8'"
#	psql -h simpldb --username postgres -d simplcommerce -a -f /app/dbscript.sql
#fi

cd /app && dotnet SimplCommerce.WebHost.dll 
