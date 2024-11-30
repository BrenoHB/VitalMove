# VitalMove

#  COMANDOS PARA INSTALAR BIBLIOTECAS EM /Back/VitalMove

dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.0
dotnet add package Microsoft.Data.SqlClient --version 5.2.2
dotnet add package MySql.Data --version 9.1.0
dotnet add package mysqlclient --version 5.5.2
dotnet add package Swashbuckle.AspNetCore --version 7.0.0


# COMANDOS PARA INICIAR O PROJETO:
DOTNET RUN

# ENDEREÇO
Localhost:XXXX/swagger
(a porta vai ser exibida no terminal).

# Criar banco
CREATE DATABASE vitalmove;

use vitalmove;

CREATE TABLE alimentacao (
  ID int(11) NOT NULL AUTO_INCREMENT,
  horario char(6) DEFAULT NULL,
  alimentos char(250) DEFAULT NULL,
  KCAL float DEFAULT NULL,
  comentario char(250) DEFAULT NULL,
  DataAlteracao date DEFAULT curdate(),
  usuario varchar(100) DEFAULT NULL,
  PRIMARY KEY (ID)
) ;


CREATE TABLE atfisica (
  ID int(11) NOT NULL AUTO_INCREMENT,
  modalidade varchar(70) DEFAULT NULL,
  TempoExecMin int(11) DEFAULT NULL,
  distancia int(11) DEFAULT NULL,
  KCAL float DEFAULT NULL,
  TempoDescanso int(11) DEFAULT NULL,
  DataAlteracao datetime DEFAULT current_timestamp(),
  usuario varchar(100) NOT NULL,
  PRIMARY KEY (ID)
);


CREATE TABLE imc (
  ID int(11) NOT NULL AUTO_INCREMENT,
  peso float DEFAULT NULL,
  altura float DEFAULT NULL,
  IMC float DEFAULT NULL,
  DataAlteracao datetime DEFAULT curdate(),
  usuario varchar(100) DEFAULT NULL,
  PRIMARY KEY (ID)
);




CREATE TABLE usuarios (
  ID int(11) NOT NULL AUTO_INCREMENT,
  usuario varchar(70) DEFAULT NULL,
  CPF char(11) DEFAULT NULL,
  DataAlteracao datetime DEFAULT current_timestamp(),
  senha varchar(100) NOT NULL,
  PRIMARY KEY (ID)
);

