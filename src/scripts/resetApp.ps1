# remove dirs
Remove-Item "../temp/csv" -recurse
Remove-Item "../temp/json" -recurse
Remove-Item "../temp/sql" -recurse
Remove-Item "../temp/json_out" -recurse

# drop TestDb
sqlcmd -S "(localdb)\mssqllocaldb" -E -i dropTestDb.sql

# recreate TestDb
sqlcmd -S "(localdb)\mssqllocaldb" -E -i createTestDb.sql
