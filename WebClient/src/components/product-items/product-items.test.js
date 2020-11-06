import React from "react";
import { shallow } from "enzyme";
import { ProductItems } from ".";

const items = [
  {
    username: "Amelia Suarez",
    title: "quidem molestiae enimzzzz",
    album: 3,
  },
  {
    username: "Juliana Suarez",
    title: "quidem molestiae enimbbb",
    album: 2,
  },
  {
    username: "Rommel SuareZ",
    title: "quidem molestiae enim",
    album: 1,
  },
];

describe("ItemList", () => {
  it("renders", () => {
    shallow(<ProductItems items={items} />);
  });
});
