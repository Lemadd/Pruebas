USE [CINES2015]
GO
/****** Object:  Table [dbo].[ASIENTO]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASIENTO](
	[CODIGO] [int] NOT NULL,
	[IDSALA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IDCLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [char](8) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[APELLIDO] [varchar](100) NOT NULL,
	[EMAIL] [varchar](100) NOT NULL,
	[CLAVE] [varchar](20) NOT NULL,
	[FECHAREGISTRO] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GENERO]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GENERO](
	[cod_genero] [char](8) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOCALCINE]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOCALCINE](
	[IDLOCAL] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DEPARTAMENTO] [varchar](20) NOT NULL,
	[PROVINCIA] [varchar](20) NOT NULL,
	[DISTRITO] [varchar](20) NOT NULL,
	[DIRECCION] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDLOCAL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PELICULA]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PELICULA](
	[cod_peli] [char](8) NOT NULL,
	[nombre_peli] [varchar](200) NOT NULL,
	[titulo_origen] [varchar](200) NOT NULL,
	[sinopsis] [varchar](700) NOT NULL,
	[director] [varchar](100) NULL,
	[actores] [varchar](700) NULL,
	[clasificacion] [varchar](100) NOT NULL,
	[duracion] [varchar](20) NULL,
	[pais_origen] [varchar](50) NULL,
	[fecha_estreno] [datetime] NULL,
	[cod_genero] [char](8) NULL,
	[tipo] [varchar](50) NULL,
	[estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_peli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SALA]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SALA](
	[IDSALA] [int] IDENTITY(1,1) NOT NULL,
	[IDLOCAL] [int] NOT NULL,
	[TIPOSALA] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDSALA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_genero]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_genero](
	[cod_genero] [nvarchar](128) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tb_genero] PRIMARY KEY CLUSTERED 
(
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_peliculas]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_peliculas](
	[cod_peli] [nvarchar](128) NOT NULL,
	[nombre_peli] [nvarchar](max) NULL,
	[titulo_origen] [nvarchar](max) NULL,
	[sinopsis] [nvarchar](max) NULL,
	[director] [nvarchar](max) NULL,
	[actores] [nvarchar](max) NULL,
	[clasificacion] [nvarchar](max) NULL,
	[duracion] [nvarchar](max) NULL,
	[pais_origen] [nvarchar](max) NULL,
	[fecha_estreno] [datetime] NOT NULL,
	[cod_genero] [nvarchar](128) NULL,
	[tipo] [nvarchar](max) NULL,
	[estado] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tb_peliculas] PRIMARY KEY CLUSTERED 
(
	[cod_peli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[dni] [nvarchar](128) NOT NULL,
	[clave] [nvarchar](max) NULL,
	[ultimafechaingreso] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tb_usuario] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 16/10/2015 1:12:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[DNI] [char](8) NOT NULL,
	[CLAVE] [char](8) NOT NULL,
	[ULTIMAFECHAINGRESO] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000001', N'Accion')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000002', N'Aventura')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000003', N'Ciencia Ficcion')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000004', N'Comedia')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000005', N'Drama')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000006', N'Fantasia')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000007', N'Melodrama')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000008', N'Romance')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000009', N'Suspenso')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000010', N'Terror')
INSERT [dbo].[GENERO] ([cod_genero], [descripcion]) VALUES (N'G0000011', N'Animacion')
INSERT [dbo].[PELICULA] ([cod_peli], [nombre_peli], [titulo_origen], [sinopsis], [director], [actores], [clasificacion], [duracion], [pais_origen], [fecha_estreno], [cod_genero], [tipo], [estado]) VALUES (N'PE000001', N'Asu mare 2', N'Asu mare 2', N'Secuela de "¡Asu Mare!", la película más taquillera en la historia de Perú', N'Ricardo Maldonado', N'Carlos Alcántara, Emilio Drago, Anahi de Cárdenas, Andrés Silva, Ana Cecilia Natteri', N'14', N'100', N'Peru', CAST(N'2015-04-09 00:00:00.000' AS DateTime), N'G0000004', N'Normal', N'Activo')
INSERT [dbo].[PELICULA] ([cod_peli], [nombre_peli], [titulo_origen], [sinopsis], [director], [actores], [clasificacion], [duracion], [pais_origen], [fecha_estreno], [cod_genero], [tipo], [estado]) VALUES (N'PE000002', N'Rapidos y furiosos 7', N'Fast & Furious 7', N'Owen Shaw, el hermano de Ian, clama venganza contra el equipo de Dominic Torreto. Séptima entrega de la saga "Rapidos y furiosos"', N'James Wan', N'Vin Diesel, Paul Walker, Dwayne "The Rock" Johnson, Jason Statham, Michelle Rodriguez, Tyrese Gibson, Elsa Pataky, Tony Jaa, Nathalie Emmanuel, Jordana Brewster, Kurt Russell, Romeo Santos, Djimon Hounsou, Ronda Rousey, Chelsea Pereira, Iggy Azalea, Lucas Black, Brittney Alger, Catherine Chen, Janell Islas', N'14', N'134', N'Estados Unidos de América', CAST(N'2015-04-02 00:00:00.000' AS DateTime), N'G0000001', N'Normal', N'Activo')
INSERT [dbo].[PELICULA] ([cod_peli], [nombre_peli], [titulo_origen], [sinopsis], [director], [actores], [clasificacion], [duracion], [pais_origen], [fecha_estreno], [cod_genero], [tipo], [estado]) VALUES (N'PE000003', N'Avengers Era de Ultron', N'Avengers: Age of Ultron', N'Cuando Tony Stark intenta reactivar un programa sin uso que tiene como objetivo de mantener la paz, las cosas comienzan a torcerse y los héroes más poderosos de la Tierra, incluyendo a Iron Man, Capitán América, Thor, El Increíble Hulk, Viuda Negra y Ojo de Halcón, se verán ante su prueba definitiva cuando el destino del planeta se ponga en juego. Cuando el villano Ultron emerge, le corresponderá a Los Vengadores detener sus terribles planes, que junto a incómodas alianzas llevarán a una inesperada acción que allanará el camino para una épica y única aventura.', N'Joss Whedon', N'Robert Downey, Jr., Chris Evans, Mark Ruffalo, Chris Hemsworth, Scarlett Johansson, Jeremy Renner, Aaron Taylor-Johnson, Elizabeth Olsen, James Spader, Paul Bettany, Cobie Smulders, Stellan Skarsgård, Samuel L. Jackson', N'14', N'141', N'Estados Unidos de América', CAST(N'2015-04-30 00:00:00.000' AS DateTime), N'G0000003', N'Normal', N'Activo')
INSERT [dbo].[PELICULA] ([cod_peli], [nombre_peli], [titulo_origen], [sinopsis], [director], [actores], [clasificacion], [duracion], [pais_origen], [fecha_estreno], [cod_genero], [tipo], [estado]) VALUES (N'PE000004', N'Naruto: La película', N'The last: Naruto the movie', N'La luna se acerca peligrosamente a la Tierra. A menos que alguien haga algo, la luna se desintegrará, inundando la tierra con meteoritos gigantescos. A medida que el reloj avanza hacia el fin del mundo, ¿Podrá Naruto ser capaz de salvar la tierra de esta crisis? Este será el último capítulo de la historia de Naruto.', N'Tsuneo Kobayashi', N'Sin Actores', N'Apta', N'113', N'Japon', CAST(N'2015-05-14 00:00:00.000' AS DateTime), N'G0000011', N'Normal', N'Activo')
INSERT [dbo].[USUARIO] ([DNI], [CLAVE], [ULTIMAFECHAINGRESO]) VALUES (N'06745783', N'06745783', CAST(N'2015-01-01 00:00:00.000' AS DateTime))
ALTER TABLE [dbo].[CLIENTE] ADD  DEFAULT (getdate()) FOR [FECHAREGISTRO]
GO
ALTER TABLE [dbo].[ASIENTO]  WITH CHECK ADD FOREIGN KEY([IDSALA])
REFERENCES [dbo].[SALA] ([IDSALA])
GO
ALTER TABLE [dbo].[PELICULA]  WITH CHECK ADD FOREIGN KEY([cod_genero])
REFERENCES [dbo].[GENERO] ([cod_genero])
GO
ALTER TABLE [dbo].[SALA]  WITH CHECK ADD FOREIGN KEY([IDLOCAL])
REFERENCES [dbo].[LOCALCINE] ([IDLOCAL])
GO
ALTER TABLE [dbo].[tb_peliculas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tb_peliculas_dbo.tb_genero_cod_genero] FOREIGN KEY([cod_genero])
REFERENCES [dbo].[tb_genero] ([cod_genero])
GO
ALTER TABLE [dbo].[tb_peliculas] CHECK CONSTRAINT [FK_dbo.tb_peliculas_dbo.tb_genero_cod_genero]
GO
ALTER TABLE [dbo].[PELICULA]  WITH CHECK ADD  CONSTRAINT [CK01] CHECK  (([tipo]='Estreno' OR [tipo]='Normal'))
GO
ALTER TABLE [dbo].[PELICULA] CHECK CONSTRAINT [CK01]
GO
ALTER TABLE [dbo].[PELICULA]  WITH CHECK ADD  CONSTRAINT [ck02] CHECK  (([estado]='Inactivo' OR [estado]='Activo'))
GO
ALTER TABLE [dbo].[PELICULA] CHECK CONSTRAINT [ck02]
GO
ALTER TABLE [dbo].[SALA]  WITH CHECK ADD CHECK  (([TIPOSALA]='2D' OR [TIPOSALA]='3D'))
GO
