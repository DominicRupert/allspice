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
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP ,
        name varchar(255),
        description TEXT ,
        category varchar(255) ,
        image varchar(255) ,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

    CREATE TABLE
        IF NOT EXISTS ingredients (
            id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
            createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
            updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
            name varchar(255) NOT NULL,
            description TEXT ,
           recipieId INT NOT NULL ,
            FOREIGN KEY (recipieId) REFERENCES recipies(id) ON DELETE CASCADE
        ) default charset utf8;
    CREATE TABLE
    IF NOT EXISTS steps(
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        stepnum INT NOT NULL,
        description TEXT ,
        recipieId INT NOT NULL ,
        FOREIGN KEY (recipieId) REFERENCES recipies(id) ON DELETE CASCADE
    ) default charset utf8;
    CREATE TABLE
    IF NOT EXISTS favorites(
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        recipieId INT NOT NULL ,
        userId VARCHAR(255) NOT NULL,
        FOREIGN KEY (recipieId) REFERENCES recipies(id) ON DELETE CASCADE,
        FOREIGN KEY (userId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8;
