CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(20) NOT NULL,
    email VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE parents (
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    nrc_or_passport VARCHAR(50) NOT NULL,
    contact_info VARCHAR(100)
);

CREATE TABLE births (
    id SERIAL PRIMARY KEY,
    brn VARCHAR(30) UNIQUE NOT NULL,
    child_full_name VARCHAR(100) NOT NULL,
    date_of_birth DATE NOT NULL,
    place_of_birth VARCHAR(100) NOT NULL,
    gender VARCHAR(10) NOT NULL,
    nationality VARCHAR(50) NOT NULL,
    birth_weight DECIMAL(5,2),
    mother_id INT REFERENCES parents(id),
    father_id INT REFERENCES parents(id),
    date_of_registration DATE NOT NULL,
    hospital VARCHAR(100),
    registration_office VARCHAR(100),
    status VARCHAR(20) NOT NULL,
    created_by INT REFERENCES users(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE certificates (
    id SERIAL PRIMARY KEY,
    birth_id INT REFERENCES births(id),
    certificate_pdf_url VARCHAR(255),
    qr_code_data VARCHAR(255),
    serial_number VARCHAR(50),
    issued_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE audit_logs (
    id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(id),
    action VARCHAR(50) NOT NULL,
    entity VARCHAR(50) NOT NULL,
    entity_id INT NOT NULL,
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    details TEXT
);