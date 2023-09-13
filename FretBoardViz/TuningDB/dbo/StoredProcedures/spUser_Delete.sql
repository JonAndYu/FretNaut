CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS	
BEGIN
	DELETE
	FROM dbo.[Users]
	WHERE UserId = @Id
END
