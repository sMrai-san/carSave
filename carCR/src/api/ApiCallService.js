import axios from "axios";

const apiUrl = "https://localhost:7280/api/CarData/";

class ApiCall {

    loadCars() {
        return axios.get(apiUrl);
    }

    addCar(car) {
        return axios.post(apiUrl, car);
    }

    deleteCar(row) {
        return axios.delete(apiUrl + row.carId);
    }
}

export default new ApiCall();