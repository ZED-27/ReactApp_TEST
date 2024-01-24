import React, { useState, useEffect, Component } from 'react';
import { Route, Routes, useParams, Link } from 'react-router-dom';
import CreatePhoneForm from "./CreatePhoneForm";
import DeletePhoneBtn from "./DeletePhoneBtn"

export default function AllPhone() {
    const [phones, setPhones] = useState([]);

    useEffect(() => {
        fetch('api/phones')
            .then(response => response.json())
            .then(data => {
                setPhones(data);
            });
    }, []);

    const handleDelete = (id) => {
        const updatedPhones = phones.filter(phone => phone.id !== id);
        setPhones(updatedPhones);
    };

    return (
        <div>
            <CreatePhoneForm updatePhoneList={setPhones} />

            <p>Количество объектов: {phones.length}</p>
            {
                phones.map((phone) => (
                    <div>
                        <Link to={`${phone.id}`}>
                            <span>{phone.id} </span>
                            <span>{phone.name} </span>
                            <span>{phone.price}</span>
                        </Link>
                        <DeletePhoneBtn onDelete={handleDelete} id={phone.id} />
                    </div>
                ))
            }
        </div>
    );
}