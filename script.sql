USE [master]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ADMINLICENCIAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ADMINLICENCIAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ADMINLICENCIAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ADMINLICENCIAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ADMINLICENCIAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ADMINLICENCIAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ADMINLICENCIAS] SET  MULTI_USER 
GO
ALTER DATABASE [ADMINLICENCIAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ADMINLICENCIAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ADMINLICENCIAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ADMINLICENCIAS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ADMINLICENCIAS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ADMINLICENCIAS] SET QUERY_STORE = OFF
GO
USE [ADMINLICENCIAS]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](max) NULL,
	[Correo] [varchar](max) NULL,
	[Celular] [varchar](max) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuraciones]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuraciones](
	[Id_configuraciones] [int] IDENTITY(1,1) NOT NULL,
	[Carpeta_para_Licencias] [varchar](max) NULL,
	[Serial_PC] [varchar](max) NULL,
 CONSTRAINT [PK_Configuraciones] PRIMARY KEY CLUSTERED 
(
	[Id_configuraciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licencias]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licencias](
	[Id_licencia] [int] IDENTITY(1,1) NOT NULL,
	[Serial_Pc] [varchar](max) NULL,
	[Fecha_de_finalizacion] [datetime] NULL,
	[Estado] [varchar](max) NULL,
	[Periodo] [varchar](max) NULL,
	[Id_llave] [int] NULL,
	[Fecha_de_solicitud] [varchar](max) NULL,
	[Fecha_de_activacion] [varchar](max) NULL,
	[Id_cliente] [int] NULL,
	[Serial] [varchar](max) NULL,
 CONSTRAINT [PK_Lada] PRIMARY KEY CLUSTERED 
(
	[Id_licencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Llaves]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Llaves](
	[Id_llave] [int] IDENTITY(1,1) NOT NULL,
	[Id_software] [int] NULL,
	[Llave] [varchar](max) NULL,
 CONSTRAINT [PK_Llaves] PRIMARY KEY CLUSTERED 
(
	[Id_llave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Software](
	[Id_software] [int] IDENTITY(1,1) NOT NULL,
	[Software] [varchar](max) NULL,
 CONSTRAINT [PK_Software] PRIMARY KEY CLUSTERED 
(
	[Id_software] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD  CONSTRAINT [FK_Licencias_Clientes] FOREIGN KEY([Id_cliente])
REFERENCES [dbo].[Clientes] ([Id_cliente])
GO
ALTER TABLE [dbo].[Licencias] CHECK CONSTRAINT [FK_Licencias_Clientes]
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD  CONSTRAINT [FK_Licencias_Llaves] FOREIGN KEY([Id_llave])
REFERENCES [dbo].[Llaves] ([Id_llave])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Licencias] CHECK CONSTRAINT [FK_Licencias_Llaves]
GO
ALTER TABLE [dbo].[Llaves]  WITH CHECK ADD  CONSTRAINT [FK_Llaves_Software] FOREIGN KEY([Id_software])
REFERENCES [dbo].[Software] ([Id_software])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Llaves] CHECK CONSTRAINT [FK_Llaves_Software]
GO
/****** Object:  StoredProcedure [dbo].[Activar_l]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Activar_l]
@id int,
@Fecha_de_activacion datetime

as 
update Lada set  Estado = 'ACTIVADA' ,Fecha_de_activacion=@Fecha_de_activacion
where Id_licencia  =@id AND Estado='APROBADA'





GO
/****** Object:  StoredProcedure [dbo].[Aprobar_l]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Aprobar_l]
@id int

as 
update Lada set  Estado = 'APROBADA'
where Id_licencia  =@id AND Estado='PENDIENTE'






GO
/****** Object:  StoredProcedure [dbo].[backup_base]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[backup_base]
as
BACKUP DATABASE [ADMINLICENCIAS]
TO DISK =N'C:\LICENCIAADABASE\BASE\ADMINLICENCIAS.bak'
WITH DESCRIPTION =N'respaldo de la base de datos de ADMINLICENCIAS',
NOFORMAT,
INIT,
NAME=N'ADMINLICENCIAS',
SKIP,
NOREWIND,
NOUNLOAD,
STATS=10,
CHECKSUM






GO
/****** Object:  StoredProcedure [dbo].[buscar_cliente_Form]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[buscar_cliente_Form]

@letra VARCHAR(max)
AS BEGIN
SELECT       top  10 Id_cliente ,Cliente as Nombre ,Celular ,Correo 
FROM            clientes 
WHEre Cliente+Celular + Correo   LIKE  '%' + @letra+'%' 
END






GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_L]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BUSCAR_L]
@Serial_pc VARCHAR(max)
AS 
SELECT      Licencias.Serial  
FROM            dbo.Licencias 
INNER join Llaves on Llaves.Id_llave =Licencias.Id_llave 
                       inner join Software on Software.Id_software = Llaves.Id_software 
where  Serial_pc=@Serial_pc

GO
/****** Object:  StoredProcedure [dbo].[Cambiar_a_licencias_activas]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Cambiar_a_licencias_activas]

@Estado as varchar(max)
as
update Licencias set Estado =@Estado 
where Fecha_de_finalizacion >= GETDATE () 

GO
/****** Object:  StoredProcedure [dbo].[Cambiar_a_licencias_vencidas]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Cambiar_a_licencias_vencidas] 

@Estado as varchar(max)
as
update Licencias set Estado =@Estado 
where Fecha_de_finalizacion < GETDATE () 

GO
/****** Object:  StoredProcedure [dbo].[eliminar_l]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[eliminar_l]
@Licencia as varchar(max)  
as
delete from Lada where Serial_Licencia=@Licencia and Estado='ACTIVADA'







GO
/****** Object:  StoredProcedure [dbo].[eliminar_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_software]
@idsoftware int  
as
delete from Software  where 
Id_software=@idsoftware
GO
/****** Object:  StoredProcedure [dbo].[eliminarLicencia]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarLicencia]
@IdLicencia as int
as
delete from Licencias 
where Id_licencia =@IdLicencia

GO
/****** Object:  StoredProcedure [dbo].[insertar_Clientes]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Clientes]
@Cliente As varchar(MAX),
@Correo As varchar(MAX),
@Celular As varchar(MAX)
As

if EXISTS (SELECT * FROM Clientes Where Correo=@Correo and Correo<>'-')
RAISERROR ('Este correo ya fue registrado', 16,1)
Else
INSERT INTO Clientes
Values (
@Cliente,
@Correo,
@Celular)





GO
/****** Object:  StoredProcedure [dbo].[Insertar_lic]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_lic]

	
	
	@Serial_Licencia varchar(max),
	 @Fecha_de_finalizacion datetime,
	 @Estado varchar(max),
	   @Periodo varchar(max),
	     @Id_llave int,
		 @Fecha_de_solicitud varchar(max),
		 @Fecha_de_activacion varchar(max),
		 @Id_cliente int,
		 @Serial as varchar(max)
    as

BEGIN
    INSERT INTO Licencias values 
	( 
	@Serial_Licencia ,
	 @Fecha_de_finalizacion ,
	 @Estado, 	
	   @Periodo,
	   @Id_llave,
	   @Fecha_de_solicitud ,
	   @Fecha_de_activacion,
	   @Id_cliente,@Serial)
	   
	   end






GO
/****** Object:  StoredProcedure [dbo].[Insertar_llave]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Insertar_llave]
@Software varchar(max),
@Llave as varchar(max)
as
begin
if exists(Select Software  from Software where Software =@Software )
Raiserror('Ya existe un Software registrado con este nombre',16,1)
else
insert into Software values(@Software)
end
DECLARE  @Id_Software INT
SELECT  @Id_Software = scope_identity()
INSERT INTO Llaves
          
     VALUES (@Id_software,@Llave)




GO
/****** Object:  StoredProcedure [dbo].[insertar_usuario]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_usuario]
@Login varchar(max),
@Password varchar(max),
@Correo varchar(max),
@Estado varchar(max)
as 
if EXISTS (SELECT Login FROM Usuarios where Login  = @login and Estado='ACTIVO'  )
RAISERROR ('YA EXISTE UN REGISTRO CON ESE USUARIO, POR FAVOR INGRESE DE NUEVO', 16,1)
else
insert into Usuarios 
values (@Login, @Password ,@Correo,@Estado)




GO
/****** Object:  StoredProcedure [dbo].[Licencias_activas]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Licencias_activas]
@Estado as varchar(max)
as
SELECT        dbo.Licencias.Id_licencia, dbo.Clientes.Cliente, dbo.Software.Software, dbo.Licencias.Periodo,
Licencias.Fecha_de_finalizacion as [Fecha de Termino]  ,dbo.Licencias.Estado
FROM            dbo.Licencias INNER JOIN
                         dbo.Llaves ON dbo.Licencias.Id_llave = dbo.Llaves.Id_llave INNER JOIN
                         dbo.Software ON dbo.Llaves.Id_software = dbo.Software.Id_software INNER JOIN
                         dbo.Clientes ON dbo.Licencias.Id_cliente = dbo.Clientes.Id_cliente
where Licencias .Estado =@Estado




GO
/****** Object:  StoredProcedure [dbo].[Licencias_vencidas]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Licencias_vencidas]
@Estado as varchar(max)
as
SELECT        dbo.Licencias.Id_licencia, dbo.Clientes.Cliente, dbo.Software.Software, dbo.Licencias.Periodo,
Licencias.Fecha_de_finalizacion as [Fecha de Termino]  ,dbo.Licencias.Estado
FROM            dbo.Licencias INNER JOIN
                         dbo.Llaves ON dbo.Licencias.Id_llave = dbo.Llaves.Id_llave INNER JOIN
                         dbo.Software ON dbo.Llaves.Id_software = dbo.Software.Id_software INNER JOIN
                         dbo.Clientes ON dbo.Licencias.Id_cliente = dbo.Clientes.Id_cliente
where Licencias .Estado =@Estado



GO
/****** Object:  StoredProcedure [dbo].[mostrar_estado_de_licencia]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_estado_de_licencia]

@Serial varchar(50)
as
select*from Licencias 




GO
/****** Object:  StoredProcedure [dbo].[mostrar_Idllave_por_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_Idllave_por_software]
@idllave int
as
select llave from Llaves
where Id_llave  =@idllave




GO
/****** Object:  StoredProcedure [dbo].[mostrar_idsoftware_por_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_idsoftware_por_software]
@Software as varchar(max)
as
select * from 
Software
where Software= @Software




GO
/****** Object:  StoredProcedure [dbo].[mostrar_llave_por_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_llave_por_software]
@id_software int
as
select llave from Llaves
where Id_software=@id_software




GO
/****** Object:  StoredProcedure [dbo].[mostrar_llaves_por_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_llaves_por_software]
as
select Software.Software   from 
Llaves inner join Software on Software.Id_software= Llaves.Id_llave




GO
/****** Object:  StoredProcedure [dbo].[mostrar_llavesoftware_por_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_llavesoftware_por_software]
@Software as varchar(max)
as
select Llaves.Llave  from 
Llaves inner join Software on Software.Id_software= Llaves.Id_llave
where Software= @Software




GO
/****** Object:  StoredProcedure [dbo].[mostrar_software]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_software]
@letra VARCHAR(50)
as
select* from Software
where Software LIKE  '%' + @letra+'%'




GO
/****** Object:  StoredProcedure [dbo].[mostrar_software_todos]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_software_todos]

as
select Llaves.Id_llave ,Software.Software,Llaves.Llave   from Software
inner join Llaves on Llaves.Id_software  = Software.Id_software 
GO
/****** Object:  StoredProcedure [dbo].[obtener_id_de_clientes_por_correo]    Script Date: 12/04/2021 04:24:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[obtener_id_de_clientes_por_correo]
@Correo as varchar(max)
as
select Clientes.Id_cliente   from Clientes
where Clientes.Correo =@Correo 



GO
USE [master]
GO
ALTER DATABASE [ADMINLICENCIAS] SET  READ_WRITE 
GO
