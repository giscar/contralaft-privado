drop database contralaft_privado
go

/*==============================================================*/
/* Database: contralaft_privado                                 */
/*==============================================================*/
create database contralaft_privado
go

use contralaft_privado
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
create schema dbo
go

/*==============================================================*/
/* Table: ACCION                                                */
/*==============================================================*/
create table dbo.ACCION (
   N_ID_ACCION          int                  identity(1,1),
   C_NUM_CODIGO         varchar(50)          null,
   C_DES_NOMBRE         varchar(500)         null,
   C_DES_DESCRIPCION    varchar(5000)        null,
   N_FL_ACTIVO          int                  null,
   C_COD_ESTADO         varchar(500)         null,
   constraint PK_ACCION primary key (N_ID_ACCION)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: ENTIDAD                                               */
/*==============================================================*/
create table dbo.ENTIDAD (
   N_COD_ENTIDAD        int                  identity(1,1),
   C_DES_RAZON          varchar(200)         null,
   C_COD_RUC            varchar(50)          null,
   C_USU_REGISTRO       varchar(50)          null,
   D_FEC_REGISTRO       datetime             null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: INDICADOR                                             */
/*==============================================================*/
create table dbo.INDICADOR (
   N_ID_INDICADOR       int                  identity(1,1),
   N_ID_ACCION          int                  null,
   C_DES_DETALLE        varchar(500)         null,
   N_COD_ESTADO         int                  null,
   N_FL_ACTIVO          int                  null,
   C_USU_REGISTRO       varchar(500)         null,
   D_FEC_REGISTRO       datetime             null,
   constraint PK_INDICADOR primary key (N_ID_INDICADOR)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: INDICADORENTIDAD                                      */
/*==============================================================*/
create table dbo.INDICADORENTIDAD (
   N_ID_INDICADOR       int                  null,
   N_ID_ENTIDAD         int                  null,
   N_COD_ESTADO         int                  null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: MENU                                                  */
/*==============================================================*/
create table dbo.MENU (
   N_COD_MENU           int                  identity(1,1),
   N_COD_PADRE          int                  null,
   C_DES_NOMBRE         varchar(50)          null,
   C_COD_ICON           varchar(50)          null,
   C_NOM_PAGE           varchar(50)          null,
   N_FL_ACTIVO          int                  null,
   constraint PK_MENU primary key (N_COD_MENU)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: MENUROL                                               */
/*==============================================================*/
create table dbo.MENUROL (
   N_COD_MENU           int                  null,
   N_COD_ROL            int                  null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: PERFIL                                                */
/*==============================================================*/
create table dbo.PERFIL (
   N_COD_PERFIL         int                  identity(1,1),
   C_DET_NOMBRE         varchar(100)         null,
   N_FL_ACTIVO          int                  null,
   C_DET_DETALLE        varchar(1000)        null,
   C_USU_REGISTRO       varchar(100)         null,
   C_USU_MODIFICACION   varchar(100)         null,
   D_FEC_REGISTRO       datetime             null,
   D_FEC_MODIFICACION   datetime             null,
   constraint PK_PERFIL primary key (N_COD_PERFIL)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: PERFILROL                                             */
/*==============================================================*/
create table dbo.PERFILROL (
   N_COD_PERFIL         int                  null,
   N_COD_ROL            int                  null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table dbo.ROL (
   N_COD_ROL            int                  identity(1,1),
   C_DES_ROL            varchar(50)          null,
   N_FL_ACTIVO          int                  null,
   C_DET_DETALLE        varchar(500)         null,
   constraint PK_ROLES primary key (N_COD_ROL)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table dbo.USUARIO (
   N_COD_ID             int                  identity(1,1),
   C_DET_CODIGO         varchar(100)         null,
   C_DET_NOMBRE         varchar(300)         null,
   N_COD_PERFIL         int                  null,
   N_COD_ENTIDAD        int                  null,
   N_FL_ACTIVO          int                  null,
   D_FEC_REGISTRO       datetime             null,
   C_USU_REGISTRO       varchar(100)         null,
   C_DET_CONTRA         varchar(500)         null
)
ON [PRIMARY]
go
