"use client";
import Search from "../../_components/Search";
import { getMockData, getUser } from "../../_api/user";
import ExploreProjectCard from "../../_components/ExploreProjectCard";
import React, { useEffect, useState } from "react";
import Loading from "../../_components/Loading";
import axios from "axios";
import { useAuthContext } from "../../_contexts/AuthContext";

const Explore = () => {
  const [data, setData] = useState([]);
  const [search, setSearch] = React.useState("");
  const [progress, setProgress] = React.useState(0);
  const [user, setUser] = useState({});
  const { state } = useAuthContext();

  useEffect(() => {
    getUser(state?.user?.id).then((res) => setUser(res.data?.data));
  }, []);

  useEffect(() => {
    axios
      .post("https://multicoloredroundcad.uysalibov.repl.co/recommend", {
        prompt: user?.description,
      })
      .then((res) => setData(res.data))
      .catch((err) => console.log(err));
    console.log("aaaaaaaa");
  }, [user]);

  return (
    <div className="pt-[130px] flex flex-col gap-10 items-center">
      <Loading progress={progress} setProgress={setProgress} />
      <div className="flex flex-col gap-6 items-center justify-center">
        <h1 className="font-bold text-4xl">
          The projects we have chosen for you.
        </h1>
        <h1 className="font-light italic text-lg px-12">
          "Unlocking the doors to a world of endless possibilities, our project
          utilizes artificial intelligence to seamlessly connect users with Open
          Science projects tailored to their unique profiles. Embrace the future
          of discovery, where science meets individuality."
        </h1>
      </div>

      <div className="border-2 border-slate-300 flex w-full rounded">
        <input
          type="text"
          className="flex-1 py-2 px-5 outline-none focus:ring-1 text-base focus:ring-slate-500 group placeholder-slate-400"
          placeholder="Search tags, keywords, etc."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
        <button className="bg-blood hover:bg-red-600 text-white py-2 px-5 rounded-r">
          Search
        </button>
      </div>

      {data?.map((project) => (
        <>{progress == 100 && <ExploreProjectCard project={project} />}</>
      ))}
    </div>
  );
};

export default Explore;
