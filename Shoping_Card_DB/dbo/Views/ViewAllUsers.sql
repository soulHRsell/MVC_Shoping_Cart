CREATE VIEW [dbo].[ViewAllUsers]
	AS 
		select u.Username, u.[Password] 
		from [User] u
