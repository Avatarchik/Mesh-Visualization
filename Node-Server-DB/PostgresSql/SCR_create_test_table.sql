CREATE TABLE test_table
(
  transaction_id integer NOT NULL,
  node_id integer,
  time_stamp abstime,
  node_status boolean,
  location location,
  CONSTRAINT id PRIMARY KEY (transaction_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE test_table
  OWNER TO postgres;