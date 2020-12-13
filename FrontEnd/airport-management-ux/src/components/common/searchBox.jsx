import React from "react";

const SearchBox = ({ value, onChange, placeholderText }) => {
  return (
    <input
      type="text"
      name="query"
      className="search"
      placeholder={placeholderText}
      value={value}
      onChange={(e) => onChange(e.currentTarget.value)}
    />
  );
};

export default SearchBox;
