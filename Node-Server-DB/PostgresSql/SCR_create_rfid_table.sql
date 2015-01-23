CREATE TABLE light_table
(
  transaction_id bigint,
  value double precision,
  CONSTRAINT "transaction id" FOREIGN KEY (transaction_id)
      REFERENCES current_table (transaction_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE light_table
  OWNER TO postgres;