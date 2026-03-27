--
-- PostgreSQL database dump
--

\restrict xAuT8O5CXhpp8AbiNgwwB7Kl0jMCecqPXiyXGNukdj0qDdtJ6eS3BYpUe7IcAyG

-- Dumped from database version 15.17
-- Dumped by pg_dump version 15.17

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: AboutsMe; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."AboutsMe" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" text NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."AboutsMe" OWNER TO website;

--
-- Name: Educations; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."Educations" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Department" text NOT NULL,
    "StartDate" date NOT NULL,
    "EndDate" date,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."Educations" OWNER TO website;

--
-- Name: ExperienceDescriptions; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."ExperienceDescriptions" (
    "Id" uuid NOT NULL,
    "ExperienceId" uuid NOT NULL,
    "Value" text NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."ExperienceDescriptions" OWNER TO website;

--
-- Name: Experiences; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."Experiences" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."Experiences" OWNER TO website;

--
-- Name: Languages; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."Languages" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."Languages" OWNER TO website;

--
-- Name: ProjectDescriptions; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."ProjectDescriptions" (
    "Id" uuid NOT NULL,
    "ProjectId" uuid NOT NULL,
    "Value" text NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."ProjectDescriptions" OWNER TO website;

--
-- Name: Projects; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."Projects" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."Projects" OWNER TO website;

--
-- Name: Skills; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."Skills" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Value" smallint NOT NULL,
    "CreatedDate" timestamp with time zone NOT NULL,
    "UpdatedDate" timestamp with time zone
);


ALTER TABLE public."Skills" OWNER TO website;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO website;

--
-- Name: logs; Type: TABLE; Schema: public; Owner: website
--

CREATE TABLE public.logs (
    message text,
    message_template text,
    level integer,
    "timestamp" timestamp without time zone,
    exception text,
    log_event jsonb
);


ALTER TABLE public.logs OWNER TO website;

--
-- Data for Name: AboutsMe; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."AboutsMe" ("Id", "Title", "Description", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: Educations; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."Educations" ("Id", "Name", "Department", "StartDate", "EndDate", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: ExperienceDescriptions; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."ExperienceDescriptions" ("Id", "ExperienceId", "Value", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: Experiences; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."Experiences" ("Id", "Title", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: Languages; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."Languages" ("Id", "Name", "Description", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: ProjectDescriptions; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."ProjectDescriptions" ("Id", "ProjectId", "Value", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: Projects; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."Projects" ("Id", "Title", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: Skills; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."Skills" ("Id", "Name", "Value", "CreatedDate", "UpdatedDate") FROM stdin;
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20260323190238_NewPcInitCreate	10.0.4
\.


--
-- Data for Name: logs; Type: TABLE DATA; Schema: public; Owner: website
--

COPY public.logs (message, message_template, level, "timestamp", exception, log_event) FROM stdin;
\.


--
-- Name: AboutsMe PK_AboutsMe; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."AboutsMe"
    ADD CONSTRAINT "PK_AboutsMe" PRIMARY KEY ("Id");


--
-- Name: Educations PK_Educations; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."Educations"
    ADD CONSTRAINT "PK_Educations" PRIMARY KEY ("Id");


--
-- Name: ExperienceDescriptions PK_ExperienceDescriptions; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."ExperienceDescriptions"
    ADD CONSTRAINT "PK_ExperienceDescriptions" PRIMARY KEY ("Id");


--
-- Name: Experiences PK_Experiences; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."Experiences"
    ADD CONSTRAINT "PK_Experiences" PRIMARY KEY ("Id");


--
-- Name: Languages PK_Languages; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."Languages"
    ADD CONSTRAINT "PK_Languages" PRIMARY KEY ("Id");


--
-- Name: ProjectDescriptions PK_ProjectDescriptions; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."ProjectDescriptions"
    ADD CONSTRAINT "PK_ProjectDescriptions" PRIMARY KEY ("Id");


--
-- Name: Projects PK_Projects; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."Projects"
    ADD CONSTRAINT "PK_Projects" PRIMARY KEY ("Id");


--
-- Name: Skills PK_Skills; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."Skills"
    ADD CONSTRAINT "PK_Skills" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_ExperienceDescriptions_ExperienceId; Type: INDEX; Schema: public; Owner: website
--

CREATE INDEX "IX_ExperienceDescriptions_ExperienceId" ON public."ExperienceDescriptions" USING btree ("ExperienceId");


--
-- Name: IX_ProjectDescriptions_ProjectId; Type: INDEX; Schema: public; Owner: website
--

CREATE INDEX "IX_ProjectDescriptions_ProjectId" ON public."ProjectDescriptions" USING btree ("ProjectId");


--
-- Name: ExperienceDescriptions FK_ExperienceDescriptions_Experiences_ExperienceId; Type: FK CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."ExperienceDescriptions"
    ADD CONSTRAINT "FK_ExperienceDescriptions_Experiences_ExperienceId" FOREIGN KEY ("ExperienceId") REFERENCES public."Experiences"("Id") ON DELETE CASCADE;


--
-- Name: ProjectDescriptions FK_ProjectDescriptions_Projects_ProjectId; Type: FK CONSTRAINT; Schema: public; Owner: website
--

ALTER TABLE ONLY public."ProjectDescriptions"
    ADD CONSTRAINT "FK_ProjectDescriptions_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES public."Projects"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

\unrestrict xAuT8O5CXhpp8AbiNgwwB7Kl0jMCecqPXiyXGNukdj0qDdtJ6eS3BYpUe7IcAyG

