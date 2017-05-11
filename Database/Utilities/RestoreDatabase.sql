-- this script is used by nant to restore the ${db-name} database

-- 1. put the ${db-name} database in single user mode
use master
if (@@error != 0) goto failed

-- 2. restore the database from the backup file
alter database ${db-name} set single_user with rollback immediate
restore database ${db-name}
    from disk = '@DUMPFILE@'
    with
		move '${db-name}' to '@DATADEVICE@'
	,   move '${db-name}_Log'  to '@LOGDEVICE@'
	,   replace
if (@@error != 0) goto failed

-- 3. Correct account issues
use ${db-name}
if (@@error != 0) goto failed

exec sp_changedbowner 'sa'
if (@@error != 0) goto failed

-- 4. put the ${db-name} database back into multi user mode
alter database ${db-name} set multi_user
if (@@error != 0) goto failed

goto goodbye

failed:

raiserror('The database restore script failed. Additional error details should be available above.', 16, 1)

goodbye:

use master


