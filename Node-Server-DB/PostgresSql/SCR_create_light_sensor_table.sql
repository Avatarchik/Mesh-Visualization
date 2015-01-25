CREATE TABLE light_sensor_table
(
  transaction_id bigint NOT NULL,
  value double precision,
  CONSTRAINT "transaction id" PRIMARY KEY (transaction_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE light_sensor_table
  OWNER TO postgres;