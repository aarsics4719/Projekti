BEGIN TRANSACTION

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

BEGIN TRY
	CREATE TABLE [dbo].[Renta](
		[RentaID] [int] IDENTITY(1,1) NOT NULL,
		[FilmID] [int] NULL,
		[KorisniciID] [int] NULL,
		[Datum] [date] NULL,
		[Komentar] [nvarchar](300) NULL,
		[Ocena_korisnika] [decimal](18, 1) NULL,
	 CONSTRAINT [PK_Renta] PRIMARY KEY CLUSTERED 
	(
		[RentaID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Renta]  WITH CHECK ADD  CONSTRAINT [FK_Renta_Filmovi] FOREIGN KEY([FilmID])
	REFERENCES [dbo].[Filmovi] ([FilmID])

	ALTER TABLE [dbo].[Renta] CHECK CONSTRAINT [FK_Renta_Filmovi]

	ALTER TABLE [dbo].[Renta]  WITH CHECK ADD  CONSTRAINT [FK_Renta_Korisnici] FOREIGN KEY([KorisniciID])
	REFERENCES [dbo].[Korisnici] ([KorisniciID])

	ALTER TABLE [dbo].[Renta] CHECK CONSTRAINT [FK_Renta_Korisnici]

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	PRINT ERROR_MESSAGE();
	PRINT 'Rollback is executed'
	ROLLBACK;
END CATCH
