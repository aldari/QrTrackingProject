﻿DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'MasterDetail.WebApp.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201601240841119_AutomaticMigration'
BEGIN
    CREATE TABLE [dbo].[QrCodes] (
        [Id] [int] NOT NULL IDENTITY,
        [Barcode] [nvarchar](255),
        [QrCodeLine] [nvarchar](255),
        [ScanDateTime] [datetime] NOT NULL,
        [Tracking_Id] [int],
        CONSTRAINT [PK_dbo.QrCodes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[QrTrackings] (
        [Id] [int] NOT NULL IDENTITY,
        [OrderDate] [datetime] NOT NULL,
        [MoNum] [nvarchar](255) NOT NULL,
        [QrShift] [nvarchar](255) NOT NULL,
        [QrOperators] [nvarchar](255) NOT NULL,
        [QrComments] [nvarchar](255) NOT NULL,
        CONSTRAINT [PK_dbo.QrTrackings] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Tracking_Id] ON [dbo].[QrCodes]([Tracking_Id])
    ALTER TABLE [dbo].[QrCodes] ADD CONSTRAINT [FK_dbo.QrCodes_dbo.QrTrackings_Tracking_Id] FOREIGN KEY ([Tracking_Id]) REFERENCES [dbo].[QrTrackings] ([Id])
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201601240841119_AutomaticMigration', N'MasterDetail.WebApp.Migrations.Configuration',  0x1F8B0800000000000400ED59DB6EE336107D2FD07F10F458642D278B05BA81BD8BAC93144637978DB2DBBE2D6869EC104B912A4905368A7E591FFA49FD850E751765D9B2E1244551E425E2E5706678E6C2F1DF7FFE357ABF8C98F3085251C1C7EEF160E83AC0031152BE18BB899EBFFAD17DFFEEFBEF461761B474BE14EB5E9B75B893ABB1FBA0757CEA792A788088A8414403299498EB4120228F84C23B190EDF7AC7C71E20848B588E33BA4BB8A611A41FF839113C805827845D891098CAC771C64F519D6B12818A490063F78A280DF21C34A16CF00BCCCEE2787081687AE53A678C1294C80736771DC2B9D044A3BCA79F15F85A0ABEF0631C20EC7E1503AE9B13A620D7E3B45ADE57A5E18951C9AB36165041A2B48876043C7E9DDBC8B3B7EF6569B7B4215A31B38FD13AB5E4D8FD24276868D7B18F3A9D3069966D32F320DB7CE4AC59725452049964FE8E9C49C2742261CC21D192B023E73699311AFC0CAB7BF10DF898278CD585457171AE318043B752C420F5EA0EE6B90AD3D075BCE63ECFDE586EABEDC9D49B72FDFAC475AEF17032635072A1660A5F0B093F0107493484B744A3B2DC6040CE366FE3591F880C521B670722FFD0A55C34DAF223F0857E18BB276FDEB8CE255D42588CE4427CE6D46C1DBB5A26B0ED9CEC363E52FEF447F901E1E7688C7B74DDE2B0EABB654B0BEC9A3CD2456A5A0BF65E92E05B2AF11DB074817AA071E6C648B662FA6BA6A94245A488EE044B95B767BFDE13B9008DE289CE25BE4864600938F22A27D9E23A95BC7BBA4F01F0BF0B6DE6DB8D0CD138B87577B2594857E23A890EE01F3B1EFB49FA0F74AE5FE2E09BD8185D48F512874F4414E1153FC7D99D51A58C1687082A45C4D810548AB8D327A89C2925029A4AD58A2AA5444D3D2F78E86C172FB3765345343BC60F1A63C44051C6EE7030386E9971237C1952EBF05901D184FEC156BFA6683BA862D587710F83436E838BB91981A55E1358B182CB63ABCA9961CB6F107DD0F6ED57176049DE32800D5098613D48655D0BA8A6F23AB48A70B585DDB4B483782F1A94BA586A783BA115B7DE40CB65B7B34653E9351E50DE7555DA7B596D5FBC01BC8E47C0E88AC4B191BFDA998F387EF62298BCF2772F91A30CC30BD49A4AB994B63C0923295980358B47A3A497542A8D9989CC88894F93306A2DAB98DD41BAE29C2679DBD755D0B0586FFECF33DCB67ADD46ABEC7889AA99709D6A09ADEB6E6F4CDF658411B9A63698089644BCABBED8B4BB2C98EB10E5607F9C7A415C87AA8FF7476BD6BC75BCE64C1B71E459F6B5AFD36BDDA7E555363D7A92A7F2F88311A88C76FB90A87BF3D310A95636D6416AC3FDB1F2C2B18E930FED42C8BC0A6CB2311FDC05A756D435B16A13BB394A51A7D98E528C3F3FAD9BA9A48BDB551ADD91C1D5C67ED1CEE4C896DDBA326FDB58BDE85DC2ADE3B9B15729C15EC2E5897C4FE1769609535D48D3D276AA4CF55E56EE3D55B6AB89364B5A4585BDA4E468595C5845C4284FE8DBDB8DAD0C9F2D711D54FF918626BBFB2BE45D34300B06FE6F6CC2287A45B5E08A703A07A5B3B7BA7B323C3EB13A95FF9EAEA1A754C87AB50E9FBDDD408D4DB73614767CAA5A4D3AFE88DF0F44B65FAA15EE7E3DB94321AF6BC185F8ADF7E98A349CB066E5D6EB6BCA43588EDDDFD37DA7CEF4D7AFB5AD474E9A594F9DA1F3C76675F6E9B1FD3778D6EA64ED7D678D4E561F56EDD3A83A206EAB0F75406CBBCDB427F41377690ED59699D47F4DE8DD83313FB6C11CA4212E619831959698335B55DBADA43CA031616DF9DB85431F9F33762D41ED997388811B676A6AD7E7A42DC552896C05806D46D8B157D57EF8F7E9476D6847656505068699C04BCEB8DAD56EE9EE556D6955AD3FA4B343F402BDAC8EE6D596DE55DDB6F55AFE49FA54EDD211D955FB3D1BC9ADE8A28230053187A0C1AB72CD94CF45C1714BA262899D00F07D83D9839C494DE724D0381D8052A991BE109698466A348370CA6F121D271A558668C61A3FB61837D9747EDA8C6BCA3CBA89D326FA21544031A9498037FC43425958CA7DB92636774098EBCDF3B3B94B6DF2F46255225D0BBBCBD305949BAF0C1BF710C50CC1D40DF7C923EC23DB67051F61418255F102E806D97E114DB38FCE29594812A91CA3DA8F9FC8E1305ABEFB074103D09CD6210000 , N'6.1.1-30610')
END
