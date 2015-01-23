
CREATE OR REPLACE FUNCTION update_db(key INT, n_status boolean, loc location) RETURNS bigint AS
$$
DECLARE
	next_val bigint;
BEGIN
    LOOP
		next_val = nextval('transaction_id_seq');
        -- first try to update the key
        UPDATE current_table SET (node_status, location, transaction_id) = (n_status, loc, next_val) WHERE node_id = key;
        IF FOUND THEN
            RETURN next_val;
        END IF;
        -- not there, so try to insert the key
        -- if someone else inserts the same key concurrently,
        -- we could get a unique-key failure
        BEGIN
            INSERT INTO current_table (node_id, node_status, location, transaction_id) VALUES (key, n_status, loc, next_val);
            RETURN next_val;
        EXCEPTION WHEN unique_violation THEN
            -- do nothing, and loop to try the UPDATE again
        END;
    END LOOP;
END;
$$
LANGUAGE plpgsql;