SELECT SETVAL((SELECT pg_get_serial_sequence('current_table', 'transaction_id')), 1, false);