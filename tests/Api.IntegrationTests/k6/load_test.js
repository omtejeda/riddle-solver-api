import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
    vus: 100,
    duration: '30s',
};

export default function () {
    const url = 'http://host.docker.internal:5045/api/v1/riddles/waterjug';
    const payload = payloads[Math.floor(Math.random() * payloads.length)];

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const response = http.post(url, JSON.stringify(payload), params);

    check(response, {
        'is status 200': (r) => r.status === 200,
    });

    sleep(1);
}

const payloads = [
    { capacityX: 2, capacityY: 10, amountWanted: 4 },
    { capacityX: 2, capacityY: 100, amountWanted: 96 },
    { capacityX: 3, capacityY: 5, amountWanted: 4 },
    { capacityX: 5, capacityY: 2, amountWanted: 4 },
    { capacityX: 7, capacityY: 3, amountWanted: 4 },
    { capacityX: 5, capacityY: 3, amountWanted: 1 },
    { capacityX: 8, capacityY: 3, amountWanted: 5 },
    { capacityX: 10, capacityY: 6, amountWanted: 4 },
    { capacityX: 10, capacityY: 4, amountWanted: 6 },
    { capacityX: 10, capacityY: 10, amountWanted: 10 },
    { capacityX: 5, capacityY: 3, amountWanted: 3 },
    { capacityX: 15, capacityY: 7, amountWanted: 14 },
    { capacityX: 6, capacityY: 8, amountWanted: 4 },
    { capacityX: 8, capacityY: 10, amountWanted: 6 },
    { capacityX: 12, capacityY: 6, amountWanted: 6 },
    { capacityX: 9, capacityY: 4, amountWanted: 5 },
    { capacityX: 14, capacityY: 6, amountWanted: 8 },
    { capacityX: 3, capacityY: 9, amountWanted: 6 },
    { capacityX: 11, capacityY: 5, amountWanted: 1 },
    { capacityX: 13, capacityY: 8, amountWanted: 5 },
    { capacityX: 16, capacityY: 4, amountWanted: 12 },
    { capacityX: 6, capacityY: 10, amountWanted: 2 },
    { capacityX: 4, capacityY: 10, amountWanted: 4 },
    { capacityX: 5, capacityY: 9, amountWanted: 1 },
    { capacityX: 30, capacityY: 10, amountWanted: 20 },
    { capacityX: 50, capacityY: 30, amountWanted: 20 },
    { capacityX: 12, capacityY: 5, amountWanted: 6 },
    { capacityX: 7, capacityY: 3, amountWanted: 1 },
    { capacityX: 9, capacityY: 4, amountWanted: 3 },
    { capacityX: 13, capacityY: 6, amountWanted: 11 },
    { capacityX: 11, capacityY: 8, amountWanted: 4 },
    { capacityX: 13, capacityY: 9, amountWanted: 6 },
    { capacityX: 10, capacityY: 7, amountWanted: 6 }
];