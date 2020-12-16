CREATE TABLE lists(
  id INT AUTO_INCREMENT NOT NULL,
  title VARCHAR(80),
  isActive TINYINT NOT NULL,
  creatorId VARCHAR(80) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
        REFERENCES profiles(id)
        ON DELETE CASCADE
)
-- CREATE TABLE profiles (
--     id VARCHAR(80) NOT NULL,
--     name VARCHAR(80) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )
-- INSERT INTO lists(
--   title,
--   isActive
-- )
-- VALUES(
--   "Groceries List",
--   true
-- )

-- DROP TABLE lists