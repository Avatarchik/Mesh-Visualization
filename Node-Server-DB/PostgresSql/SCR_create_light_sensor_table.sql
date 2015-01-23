CREATE TABLE light_sensor_table
(
  transaction_id integer NOT NULL,
  light_value double precision,
  CONSTRAINT t_id FOREIGN KEY (transaction_id)
      REFERENCES current_nodes_table (transaction_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE light_sensor_table
  OWNER TO postgres;