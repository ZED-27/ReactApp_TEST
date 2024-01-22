import React, { useState, useEffect, Component } from 'react';
import { Route, Routes, useParams, Link } from 'react-router-dom';

export default function CreatePhoneForm({ updatePhoneList }) {
    const [formData, setFormData] = useState({
        name: '',
        price: 0,
    });

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await fetch('/api/phones', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData)
            });
            const data = await response.json();
            updatePhoneList(data);
        } catch (error) {
            alert("error");
        }
    };

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="name">Phone</label>
            <input id="name" name="name" type="text" value={formData.name} onChange={handleChange} />
            <label htmlFor="price">Price</label>
            <input id="price" name="price" type="number" value={formData.price} onChange={handleChange} />
            <button type="submit">Submit</button>
        </form>
    );
}
    

    