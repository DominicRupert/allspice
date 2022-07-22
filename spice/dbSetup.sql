CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipies (
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'Recipe Name',
        description TEXT COMMENT 'Recipe Description',
        category varchar(255) COMMENT 'Recipe Category',
        image varchar(255) COMMENT 'Recipe Picture',
        creatorId VARCHAR(255) NOT NULL COMMENT 'User Id',
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

    CREATE TABLE
        IF NOT EXISTS ingredients (
            id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
            createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
            updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
            name varchar(255) COMMENT 'Ingredient Name',
           recipieId INT NOT NULL COMMENT 'Recipe Id',
            FOREIGN KEY (recipieId) REFERENCES recipies(id) ON DELETE CASCADE
        ) default charset utf8 COMMENT '';