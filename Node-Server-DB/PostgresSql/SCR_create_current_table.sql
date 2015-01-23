CREATE TABLE current_table
(
  node_id integer,
  node_status boolean,
  location location,
  transaction_id bigint NOT NULL,
  time_stamp time with time zone,
  CONSTRAINT current_table_pkey PRIMARY KEY (transaction_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE current_table
  OWNER TO postgres;
