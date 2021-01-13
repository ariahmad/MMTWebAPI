
Information:
I have removed the connection string from the Web.config file.

Change considerations
1. Authorization: creating a class that inherit from AuthorizationFilterAtribute and overwrite onAuthorization method.
2. Logs: using log4Net for loggin all errors, warnning and informations
3. Error Handling, using try catch and finally
4. Adding comments and explaning
5. Format the date, convert them to short date