import { getMockData } from "../../../_api/user";
import React from "react";

const MyContributions = () => {
  const data = getMockData();

  return (
    <div className="flex gap-5 flex-col  flex-1">
      <div className="flex flex-col h-1/2 overflow-x-auto shadow-md sm:rounded-lg">
        <table className="w-full text-lg text-center text-gray-500 ">
          <thead className="text-sm font-extrabold tracking-wide text-center text-gray-700 uppercase bg-gray-200 ">
            <tr>
              <th scope="col" className="px-6 py-3">
                Project Name
              </th>
              <th scope="col" className="px-6 py-3">
                URL
              </th>
              <th scope="col" className="px-6 py-3">
                Status
              </th>
            </tr>
          </thead>
          <tbody>
            {data.projects.map((project, i) => (
              <tr key={i} className="bg-white border-b  hover:bg-gray-50">
                <td
                  scope="row"
                  className="px-6 py-4 font-medium text-gray-900 whitespace-nowra"
                >
                  {project.title}
                </td>
                <td className="px-6 py-4">{project.url}</td>
                <td className="px-6 py-4 text-center">{project.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default MyContributions;
