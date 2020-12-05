-- Criar banco de dados
CREATE DATABASE Brasileirao

-- Deletar banco de dados
USE master;
DROP DATABASE Brasileirao

-- Criar uma tabela de usuários
CREATE TABLE Users (
  Id UNIQUEIDENTIFIER NOT NULL,
  Name VARCHAR(100) NOT NULL,
  Profile INT NOT NULL,
  PRIMARY KEY (Id)
)

-- Deletar uma tabela
DROP TABLE Users

-- Criar um novo jogador (informando o id do time)
INSERT INTO Players VALUES (
    NEWID(),
    10,
    'fe4e52ce-b8db-4cf6-bdaa-7adecb242b0e',
    'Torcedor Torcedor'
)

-- Obter todas as colunas dos jogadores
SELECT * FROM Players

-- Deletar todos registros de uma tabela
DELETE FROM Users