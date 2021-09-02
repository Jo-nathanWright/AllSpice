CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

INSERT INTO accounts (id, name , email, picture) VALUES ("password", "SpaceCowboySpike", "j.wright72127@gmail.com", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZ3odT-9gMr_05u85PeDVIXq2hlo8hAy-OQg&usqp=CAU");

CREATE TABLE IF NOT EXISTS recipes (
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title varchar(255) COMMENT 'recipe title',
  description varchar(255) COMMENT 'recipe description',
  cookTime int COMMENT 'recipe cookTime',
  prepTime int COMMENT 'recipe prepTime',
  creatorId VARCHAR(255) NOT NULL COMMENT 'Account Id of creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
