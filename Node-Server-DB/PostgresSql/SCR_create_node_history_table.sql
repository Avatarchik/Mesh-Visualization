CREATE TABLE node_history_table
(
  transaction_id bigint NOT NULL,
  location location,
  status boolean,
  node_id integer,
  ip_address character varying(15),
  CONSTRAINT trans_id PRIMARY KEY (transaction_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE node_history_table
  OWNER TO postgres;