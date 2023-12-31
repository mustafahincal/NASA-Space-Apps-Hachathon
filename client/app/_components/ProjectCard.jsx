import Image from "next/image";
import Link from "next/link";

const ProjectCard = ({ project }) => {
  return (
    <div className="flex flex-col   w-80 pt-1 pb-2 px-2 bg-white   rounded-md shadow-md">
      <Link
        className="flex flex-col  gap-4 group"
        href={`/projects/${project?.id}`}
      >
        <div className="relative flex items-center justify-center h-48 w-60 ">
          <Image
            src={"/assets/spaceapps-logo.jpg"}
            fill
            alt=""
            className="object-contain self-center group-hover:scale-105 transform transition-transform rounded-md"
          />
        </div>
        <div className="flex flex-col gap-2">
          <div className="flex flex-row justify-between gap-2">
            <h2
              className="text-base
         md:text-lg font-bold
         line-clamp-1
        "
            >
              {project?.title}
            </h2>
          </div>
          <span className="opacity-70">2023</span>
          <div className="mt-2">
            <p className="font-bold">
              {project?.owner.firstName + " " + project.owner.lastName}
            </p>
          </div>
        </div>
      </Link>
    </div>
  );
};

export default ProjectCard;
