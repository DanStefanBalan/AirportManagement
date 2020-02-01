import http from "./httpService";
import { apiUrl, countriesapiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/airports";

function airportUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getAirports() {
  return http.get(apiEndpoint);
}

export function getAirport(airportId) {
  return http.get(airportUrl(airportId));
}

export function saveAirport(airport) {
  if (airport.id) {
    const body = { ...airport };
    delete body.id;
    return http.put(airportUrl(airport.id), body);
  }
  return http.post(apiEndpoint, airport);
}

export function deleteAirport(airportId) {
  return http.delete(airportUrl(airportId));
}

export function getCountries() {
  return http.get(countriesapiUrl);
}
