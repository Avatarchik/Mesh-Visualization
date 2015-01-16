
CREATE FUNCTION "public"."set_time_stamp" () RETURNS trigger AS'
    BEGIN
        NEW.time_stamp = NOW();
        RETURN NEW;
    END;
    'LANGUAGE 'plpgsql' IMMUTABLE CALLED ON NULL INPUT SECURITY INVOKER;

CREATE TRIGGER "trg_set_time_stamp" BEFORE INSERT OR UPDATE
    ON "test_table" FOR EACH ROW
    EXECUTE PROCEDURE "public"."set_time_stamp"();
