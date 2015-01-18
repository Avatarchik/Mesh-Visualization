CREATE TABLE test_table
(
  node_id integer NOT NULL,
  time_stamp abstime,
  node_type integer,
  node_status boolean,
  location location,
  CONSTRAINT id PRIMARY KEY (node_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE test_table
  OWNER TO postgres;