CREATE PROCEDURE [dbo].[spUsers_Update]
    @UserId INT,
    @NewUsername NVARCHAR(50) = NULL,
    @NewPasswordHash NVARCHAR(255) = NULL,
    @NewEmail NVARCHAR(100) = NULL
AS
BEGIN
    -- Check if the @UserId exists
    IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UserId = @UserId)
    BEGIN
        -- Update the user's information
        UPDATE [dbo].[Users]
        SET Username = ISNULL(@NewUsername, Username),
            PasswordHash = ISNULL(@NewPasswordHash, PasswordHash),
            Email = ISNULL(@NewEmail, Email)
        WHERE UserId = @UserId;

        -- Return a success status or message
        SELECT 'User information updated successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the user doesn't exist
        SELECT 'User not found. Update operation failed' AS [Status];
    END
END