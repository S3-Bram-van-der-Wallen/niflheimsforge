import { json } from '@sveltejs/kit';

export async function GET(request) {
    const response = await request.fetch(`${import.meta.env.VITE_API_ENDPOINT}/countries`);

    if (response.ok) {
        const countries = await response.json();
        return json({
            body: countries
        });
    } else {
        return json({
            status: response.status,
            statusText: response.statusText
        });
    }
}

// export async function POST(countryDTO) {
//     const response = await fetch(`http://localhost:5031/countries`, {
//         method: 'POST',
//         headers: {
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(countryDTO)
//     });

//     if (response.ok) {
//         const country = await response.json();
//         return country;
//     } else {
//         console.error(`Failed to create country: ${response.statusText}`);
//         throw new Error(response.statusText);
//     }
// }

export async function POST({ request }) {
    try {
        const countryDTO = await request.json();

        const response = await fetch('http://localhost:5031/countries', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(countryDTO)
        });

        if (response.ok) {
            const country = await response.json();
            return json(country, { status: 201 });
        } else {
            const error = await response.json();
            return json({ message: 'Failed to create country', error }, { status: response.status });
        }
    } catch (error) {
        console.error('Error creating country:', error);
        return json({ message: 'Internal Server Error', error: error.message }, { status: 500 });
    }
}

