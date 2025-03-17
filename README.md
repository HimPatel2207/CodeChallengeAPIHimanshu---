# CodeChallengeAPIHimanshu  

1 CodeChallengeAPI (\CodeChallengeAPI)
2 UnitTest Project (\CodeChallengeAPI)
3 Frontend Angular Application  (\Frontend)

# Database (\DB-Script)

DBSchema
DBSchemaAndData

1 SQL database Script with **CodeChallengeGlasslewis** Database with Following
Tables
  1. tbl_companyData
  2. dbo.tbl_UserMaster
No Stored Procedures, Using EF Core DB Context class.

# Postman Collection For API Testing (\PostmanCollection) 

1 CodeChallengeAPI.postman_collection.json
2 CodeChallengeAPI.postman_environment.json


------------ - - - - -------------------------------- - - - - - -- - -- - -  ---- -

1. Create a Company record specifying the Name, Stock Ticker, Exchange, Isin, and optionally a website
url. You are not allowed create two Companies with the same Isin. The first two characters of an ISIN
must be letters / non numeric.
2. Retrieve an existing Company by Id
3. Retrieve a Company by ISIN
4. Retrieve a collection of all Companies
5. Update an existing Company

6. Code is testable and have unit test coverage seperate project Added. It's running end to end and read and
write to a database.

7. Also designed the database and provided all SQL scripts and source

**Bonus points:**
 Provided a client to call the api and present the results in a browser **using Angular web technology**.
  With only Company Data Listing and All other Services added like (Edit, Delete , Add) but not oprations added. 
  Only Company listed

**Even more points:**
 Added **authentication** code to secure the api
Added **Logging** 
Added **API Versioning** 
Repository pattern with **EF Core DB-Context**.
