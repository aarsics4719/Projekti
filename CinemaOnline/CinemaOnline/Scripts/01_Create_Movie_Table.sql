BEGIN TRANSACTION

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


BEGIN TRY
	CREATE TABLE [dbo].[Filmovi](
		[FilmID] [int] IDENTITY(1,1) NOT NULL,
		[Ime] [nvarchar](50) NULL,
		[Zanr] [nvarchar](50) NULL,
		[Opis] [nvarchar](300) NULL,
		[Godina] [int] NULL,
		[Ocena] [decimal](18, 1) NULL,
		[Trajanje] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Filmovi] PRIMARY KEY CLUSTERED 
	(
		[FilmID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	PRINT ERROR_MESSAGE();
	PRINT 'Rollback is executed'
	ROLLBACK;
END CATCH

