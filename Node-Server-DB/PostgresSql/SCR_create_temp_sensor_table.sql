CREATE TABLE temperature_table
(
  transaction_id integer,
  value double precision,
  CONSTRAINT "transaction id" FOREIGN KEY (transaction_id)
      REFERENCES current_table (transaction_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE temperature_table
  OWNER TO postgres;
