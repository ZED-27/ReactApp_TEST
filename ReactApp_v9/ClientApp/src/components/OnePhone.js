import React, { useState, useEffect, Component } from 'react';
import { useParams } from 'react-router-dom';

export default function OnePhone() {
    const [onePhone, setOnePhone] = useState(null);
    const { id } = useParams();

    useEffect(() => {
    fetch(`/api/phones/${id}`)
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => setOnePhone(data))
      .catch(error => console.error('Error fetching data:', error));
  }, [id]);

    return (
        <div>
            {onePhone && < div >
                <span>{onePhone.id}</span>
                <span>{onePhone.name}</span>
                <span>{onePhone.price}</span>
                </div>
            } 
        </div>
    );
}
