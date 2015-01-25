CREATE TABLE rfid_sensor_table
(
  transaction_id bigint NOT NULL,
  value text,
  CONSTRAINT "trans id" PRIMARY KEY (transaction_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE rfid_sensor_table
  OWNER TO postgres;