CREATE TABLE temperature_sensor_table
(
  transaction_id bigint NOT NULL,
  value double precision,
  CONSTRAINT transaction PRIMARY KEY (transaction_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE temperature_sensor_table
  OWNER TO postgres;
