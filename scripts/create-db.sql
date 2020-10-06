\c postgres
-- CREATE USER bamboo WITH CREATEDB ENCRYPTED PASSWORD 'bamboo_db_password';
-- ALTER USER bamboo WITH ENCRYPTED PASSWORD 'bamboo_db_password';
SELECT pg_terminate_backend(pg_stat_activity.pid) FROM pg_stat_activity WHERE datname = 'bamboo';
DROP DATABASE IF EXISTS bamboo;
CREATE DATABASE bamboo OWNER bamboo;
\c bamboo
CREATE EXTENSION if not exists timescaledb;
CREATE EXTENSION if not exists postgis;
CREATE EXTENSION if not exists "uuid-ossp";
CREATE EXTENSION IF NOT EXISTS hstore;

CREATE OR REPLACE FUNCTION next_uuid(OUT result uuid) AS $$
DECLARE
    now_micros bigint;
    second_rand bigint;
    hex_value text;
    shard_id int:=1;
BEGIN
    -- Can use clock_timestamp() / statement_timestamp() / transaction_timestamp() / current_timestamp
    select (extract(epoch from current_timestamp)*1000000)::BIGINT INTO now_micros;
    select ((random() * 10^18)::BIGINT) INTO second_rand;
    -- Uncomment below line to ignore sharding.
    -- select ((random() * 10^6)::INT) INTO shard_id;
    -- [milliseconds(6 bytes) + microseconds(12 bits) + shard(4 bits) + random(8 bytes)]
    hex_value := LPAD(TO_HEX(now_micros/1000), 12, '0')||LPAD(TO_HEX(now_micros%1000), 3, '0')||LPAD(TO_HEX(shard_id), 1, '0')||LPAD(TO_HEX(second_rand), 16, '0');
    result := CAST(hex_value AS UUID);
    -- TEST PERFOMANCE
    -- EXPLAIN ANALYZE
    -- SELECT next_uuid() FROM generate_series(1,100000);
END;
$$ LANGUAGE PLPGSQL;
ALTER FUNCTION next_uuid OWNER TO bamboo;

