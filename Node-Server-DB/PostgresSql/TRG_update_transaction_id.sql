
CREATE FUNCTION "public"."update_transaction_id" () RETURNS trigger AS
$BODY$
	DECLARE
		curr_id integer;
	BEGIN
		curr_id = nextval(pg_get_serial_sequence('current_table', 'transaction_id'));
		NEW.transaction_id = curr_id;
		RETURN NEW;
	END; 
$BODY$ LANGUAGE 'plpgsql' IMMUTABLE CALLED ON NULL INPUT SECURITY INVOKER;

CREATE TRIGGER "trg_update_transaction_id" AFTER UPDATE
    ON "current_table" FOR EACH ROW
    EXECUTE PROCEDURE "public"."update_transaction_id"();