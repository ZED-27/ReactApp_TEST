import React from 'react';

export default function DeletePhonetBtn({onDelete, id})
{
    const handleDelete = () => {
        fetch(`api/phones/${id}`, {
            method: 'DELETE'
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                onDelete(id);
            })
            .catch(error => {
                console.error('Error deleting phone:', error);
            })
    }

    return (
        <button onClick={handleDelete}>delete</button>
    );
}