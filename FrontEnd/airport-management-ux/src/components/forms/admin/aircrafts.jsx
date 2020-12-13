import React, { Component } from "react";
import { getResources, deleteResource } from "../../../services/api";
import { apiUrl } from "../../../config.json";
import Pagination from "../../common/pagination";
import { paginate } from "../../../helpers/paginate";
import AircraftTable from "../../tables/aircraftTable";
import SearchBox from "../../common/searchBox";
import "../../../styles/table.scss";
import _ from "lodash";
import SideBar from "../../common/sidebar";
import NavBar from "./../../common/navbar";

const route = `${apiUrl}aircrafts`;

class Aircrafts extends Component {
  state = {
    aircrafts: [],
    pageSize: 10,
    currentPage: 1,
    totalCount: 0,
    searchQuery: "",
    sortColumn: { path: "countryOfRegistration", order: "asc" },
  };

  getPagedData = () => {
    const {
      pageSize,
      currentPage,
      sortColumn,
      aircrafts,
      searchQuery,
    } = this.state;
    var filteredAircrafts = aircrafts;
    if (searchQuery)
      filteredAircrafts = aircrafts.filter((m) =>
        m.aircraftNumber.toLowerCase().startsWith(searchQuery.toLowerCase())
      );
    const sorted = _.orderBy(
      filteredAircrafts,
      [sortColumn.path],
      [sortColumn.order]
    );
    const aircraft = paginate(sorted, currentPage, pageSize);
    return { totalCount: aircrafts.length, data: aircraft };
  };

  async componentDidMount() {
    const { data: aircrafts } = await getResources(route);
    const totalCount = aircrafts.length;
    this.setState({ aircrafts, totalCount });
  }

  handleSearch = (query) => {
    this.setState({ searchQuery: query, currentPage: 1 });
  };

  handlePageChange = (page) => {
    this.setState({ currentPage: page });
  };

  handleSort = (sortColumn) => {
    this.setState({ sortColumn });
  };

  handleDelete = (aircraft) => {
    const aircrafts = this.state.aircrafts.filter((m) => m.id !== aircraft.id);
    this.setState({ aircrafts });
    deleteResource(aircraft.id, route);
  };

  render() {
    const { pageSize, currentPage, sortColumn, searchQuery } = this.state;
    const { totalCount, data: aircrafts } = this.getPagedData();

    return (
      <React.Fragment>
        <NavBar />
        <SideBar />
        <div className="table-wrapper">
          <div className="search-row">
            <SearchBox
              value={searchQuery}
              onChange={this.handleSearch}
              placeholderText="Search aircrafts..."
            />
            <div className="button-wrapper">
              <button className="add-button">
                <a href="/admin/add-aircraft">Add aircraft</a>
              </button>
            </div>
          </div>
          <AircraftTable
            aircrafts={aircrafts}
            onDelete={this.handleDelete}
            onSort={this.handleSort}
            sortColumn={sortColumn}
          />
          <Pagination
            itemsCount={totalCount}
            pageSize={pageSize}
            currentPage={currentPage}
            onPageChange={this.handlePageChange}
          />
        </div>
      </React.Fragment>
    );
  }
}

export default Aircrafts;
