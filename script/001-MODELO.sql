if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCION') and o.name = 'FK_ACCION_REFERENCE_PLAN')
alter table ACCION
   drop constraint FK_ACCION_REFERENCE_PLAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INDICADOR') and o.name = 'FK_INDICADO_REFERENCE_ACCION')
alter table INDICADOR
   drop constraint FK_INDICADO_REFERENCE_ACCION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INDICADORENTIDAD') and o.name = 'FK_INDICADO_REFERENCE_ENTIDAD')
alter table INDICADORENTIDAD
   drop constraint FK_INDICADO_REFERENCE_ENTIDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INDICADORENTIDAD') and o.name = 'FK_INDICADO_REFERENCE_INDICADO')
alter table INDICADORENTIDAD
   drop constraint FK_INDICADO_REFERENCE_INDICADO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MENUROL') and o.name = 'FK_MENUROL_REFERENCE_MENU')
alter table MENUROL
   drop constraint FK_MENUROL_REFERENCE_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MENUROL') and o.name = 'FK_MENUROL_REFERENCE_ROL')
alter table MENUROL
   drop constraint FK_MENUROL_REFERENCE_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERFILROL') and o.name = 'FK_PERFILRO_REFERENCE_PERFIL')
alter table PERFILROL
   drop constraint FK_PERFILRO_REFERENCE_PERFIL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERFILROL') and o.name = 'FK_PERFILRO_REFERENCE_ROL')
alter table PERFILROL
   drop constraint FK_PERFILRO_REFERENCE_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_ENTIDAD')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_ENTIDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_PERFIL')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_PERFIL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACCION')
            and   type = 'U')
   drop table ACCION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ENTIDAD')
            and   type = 'U')
   drop table ENTIDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INDICADOR')
            and   type = 'U')
   drop table INDICADOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INDICADORENTIDAD')
            and   type = 'U')
   drop table INDICADORENTIDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MENU')
            and   type = 'U')
   drop table MENU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MENUROL')
            and   type = 'U')
   drop table MENUROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERFIL')
            and   type = 'U')
   drop table PERFIL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERFILROL')
            and   type = 'U')
   drop table PERFILROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"PLAN"')
            and   type = 'U')
   drop table "PLAN"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROL')
            and   type = 'U')
   drop table ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ACCION                                                */
/*==============================================================*/
create table ACCION (
   N_COD_ACCION         int                  identity(1,1),
   N_COD_PLAN           int                  null,
   C_NUM_CODIGO         varchar(50)          null,
   C_DES_NOMBRE         varchar(500)         null,
   C_DES_DESCRIPCION    varchar(5000)        null,
   N_FL_ACTIVO          int                  null,
   C_COD_ESTADO         varchar(500)         null,
   C_USU_REGISTRO       varchar(20)          null,
   D_FEC_REGISRO        datetime             null,
   C_USU_MODIFICACION   varchar(20)          null,
   D_FEC_MODIFICACION   datetime             null,
   constraint PK_ACCION primary key (N_COD_ACCION)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: ENTIDAD                                               */
/*==============================================================*/
create table ENTIDAD (
   N_COD_ENTIDAD        int                  identity(1,1),
   C_DES_RAZON          varchar(200)         null,
   C_COD_RUC            varchar(50)          null,
   C_DET_SIGLA          varchar(50)          null,
   C_USU_REGISTRO       varchar(50)          null,
   D_FEC_REGISTRO       datetime             null,
   N_FL_ACTIVO          int                  null,
   C_USU_MODIFICACION   varchar(20)          null,
   D_FEC_MODIFICACION   datetime             null,
   constraint PK_ENTIDAD primary key (N_COD_ENTIDAD)
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: INDICADOR                                             */
/*==============================================================*/
create table INDICADOR (
   N_COD_INDICADOR      int                  identity(1,1),
   N_COD_ACCION         int                  null,
   C_DES_DETALLE        varchar(5000)        null,
   N_COD_ESTADO         int                  null,
   N_FL_ACTIVO          int                  null,
   C_USU_REGISTRO       varchar(20)          null,
   D_FEC_REGISTRO       datetime             null,
   C_USU_MODIFICACION   varchar(20)          null,
   D_FECHA_MODIFICACION datetime             null,
   constraint PK_INDICADOR primary key (N_COD_INDICADOR)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: INDICADORENTIDAD                                      */
/*==============================================================*/
create table INDICADORENTIDAD (
   N_COD_INDICADOR      int                  identity(1,1),
   N_COD_ENTIDAD        int                  null,
   N_COD_ESTADO         int                  null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: MENU                                                  */
/*==============================================================*/
create table MENU (
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
create table MENUROL (
   N_COD_MENU           int                  null,
   N_COD_ROL            int                  null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: PERFIL                                                */
/*==============================================================*/
create table PERFIL (
   N_COD_PERFIL         int                  identity(1,1),
   C_DET_NOMBRE         varchar(100)         null,
   N_FL_ACTIVO          int                  null,
   C_DET_DETALLE        varchar(1000)        null,
   C_USU_REGISTRO       varchar(20)          null,
   C_USU_MODIFICACION   varchar(20)          null,
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
create table PERFILROL (
   N_COD_PERFIL         int                  null,
   N_COD_ROL            int                  null,
   N_FL_ACTIVO          int                  null
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: "PLAN"                                                */
/*==============================================================*/
create table "PLAN" (
   N_COD_PLAN           int                  identity(1,1),
   C_NOM_PLAN           varchar(300)         null,
   C_DES_DETALLE        varchar(1000)        null,
   N_COD_VERSION        int                  null,
   N_COD_ESTADO         int                  null,
   C_USU_REGISTRO       varchar(20)          null,
   D_FECHA_REGISTRO     datetime             null,
   C_USU_MODIFICACION   varchar(20)          null,
   D_FECHA_MODIFICACION datetime             null,
   constraint PK_PLAN primary key (N_COD_PLAN)
)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   N_COD_ROL            int                  identity(1,1),
   C_DES_ROL            varchar(50)          null,
   N_FL_ACTIVO          int                  null,
   C_DET_DETALLE        varchar(1000)        null,
   C_USU_REGISTRO       varchar(20)          null,
   C_USU_MODIFICACION   varchar(20)          null,
   D_FEC_REGISTRO       datetime             null,
   D_FEC_MODIFICACION   datetime             null,
   constraint PK_ROLES primary key (N_COD_ROL)
         WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)
ON [PRIMARY]
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   N_COD_ID             int                  identity(1,1),
   N_COD_PERFIL         int                  null,
   N_COD_ENTIDAD        int                  null,
   C_DET_CODIGO         varchar(100)         null,
   C_DET_NOMBRE         varchar(300)         null,
   C_DET_CONTRA         varchar(500)         null,
   C_DET_EMAIL          varchar(300)         null,
   C_COD_DOCUMENTO      varchar(500)         null,
   N_FL_ACTIVO          int                  null,
   D_FEC_REGISTRO       datetime             null,
   C_USU_REGISTRO       varchar(100)         null,
   D_FEC_MODIFICACION   datetime             null,
   C_USU_MODIFICACION   varchar(100)         null,
   C_COD_DOC_ELIMINA    varchar(500)         null,
   constraint PK_USUARIO primary key (N_COD_ID)
)
ON [PRIMARY]
go

alter table ACCION
   add constraint FK_ACCION_REFERENCE_PLAN foreign key (N_COD_PLAN)
      references "PLAN" (N_COD_PLAN)
go

alter table INDICADOR
   add constraint FK_INDICADO_REFERENCE_ACCION foreign key (N_COD_ACCION)
      references ACCION (N_COD_ACCION)
go

alter table INDICADORENTIDAD
   add constraint FK_INDICADO_REFERENCE_ENTIDAD foreign key (N_COD_ENTIDAD)
      references ENTIDAD (N_COD_ENTIDAD)
go

alter table INDICADORENTIDAD
   add constraint FK_INDICADO_REFERENCE_INDICADO foreign key (N_COD_INDICADOR)
      references INDICADOR (N_COD_INDICADOR)
go

alter table MENUROL
   add constraint FK_MENUROL_REFERENCE_MENU foreign key (N_COD_MENU)
      references MENU (N_COD_MENU)
go

alter table MENUROL
   add constraint FK_MENUROL_REFERENCE_ROL foreign key (N_COD_ROL)
      references ROL (N_COD_ROL)
go

alter table PERFILROL
   add constraint FK_PERFILRO_REFERENCE_PERFIL foreign key (N_COD_PERFIL)
      references PERFIL (N_COD_PERFIL)
go

alter table PERFILROL
   add constraint FK_PERFILRO_REFERENCE_ROL foreign key (N_COD_ROL)
      references ROL (N_COD_ROL)
go

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_ENTIDAD foreign key (N_COD_ENTIDAD)
      references ENTIDAD (N_COD_ENTIDAD)
go

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_PERFIL foreign key (N_COD_PERFIL)
      references PERFIL (N_COD_PERFIL)
go
