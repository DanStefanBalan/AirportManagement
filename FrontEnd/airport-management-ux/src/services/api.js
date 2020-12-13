import http from "./httpService";
import { countriesapiUrl } from "../config.json";

function getResourceId(path, id) {
  return `${path}/${id}`;
}

export function getResources(path) {
  return http.get(path);
}

export function getResource(id, path) {
  return http.get(getResourceId(id, path));
}

export function saveResource(resource, path) {
  if (resource.id) {
    const body = { ...resource };
    delete body.id;
    return http.put(getResourceId(resource.id, path), body);
  }
  return http.post(path, resource);
}

export function deleteResource(id, path) {
  return http.delete(getResourceId(path, id));
}

export function getCountries() {
  return http.get(countriesapiUrl);
}

export function getAircraftsNumber() {
  return http.get("http://localhost:51044/api/aicraftNumbers");
}
