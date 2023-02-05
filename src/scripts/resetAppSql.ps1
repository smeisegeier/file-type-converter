# drop TestDb
sqlcmd -S "(localdb)\mssqllocaldb" -E -i dropTestDb.sql

# recreate TestDb
sqlcmd -S "(localdb)\mssqllocaldb" -E -i createTestDb.sql
