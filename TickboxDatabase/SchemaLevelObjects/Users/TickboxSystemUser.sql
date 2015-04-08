CREATE USER [TickboxSystemUser]
	FOR LOGIN [TickboxApi]
	WITH DEFAULT_SCHEMA = dbo
GO;

GRANT CONNECT TO [TickboxSystemUser] AS [dbo];
GO;GRANT EXECUTE ON SCHEMA::[dbo] TO [TickboxApiUser] AS [dbo];GO;
GRANT EXECUTE ON SCHEMA::[tbx] TO [TickboxSystemUser] AS [dbo];GO;
GRANT SELECT, UPDATE, INSERT, DELETE ON SCHEMA :: dbo TO [TickboxSystemUser] AS [dbo];
GO;
GRANT SELECT, UPDATE, INSERT, DELETE ON SCHEMA :: tbx TO [TickboxSystemUser] AS [dbo];
GO;
